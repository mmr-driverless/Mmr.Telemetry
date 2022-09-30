#!/usr/bin/python3

import logging
import can
import paho.mqtt.client as Client
    

"""
RETURN CODES ON CONNECTION:
0: Connection successful
1: Connection refused : incorrect protocol version
2: Connection refused : invalid client identifier
3: Connection refused : server unavailable
4: Connection refused : bad username or password
5: Connection refused : not authorised
6-255: Currently unused.
"""
def on_connect(client, userdata, flags, rc):
    if rc==0:
        logging.info("CONNECTED - Returned code=",rc)
    else:
        logging.info("Bad connection - Returned code=",rc)


"""
Simply check the bus each loop and redirect messages on a topic 
based on their can_id.
"""
def start_daemon(client):
    
    with can.interface.Bus(
        interface='socketcan', 
        channel="can0", 
        bitrate=1000000
    ) as bus:

        # set to read-only, only supported on some interfaces
        bus.state = can.bus.PASSIVE

        try:
            while True:
                msg = bus.recv(1)
                if msg is not None:
                    logging.info(f"{msg.arbitration_id:X}: {msg.data}")
                    topic = "mmr/telemetry/raw/" + msg.arbitration_id
                    data = msg.data
                    client.publish(topic, data) # If more reliability is necessary use 1 or 2 for QoS (3rd parameter, default = 0)
        except Exception as e:
            logging.error(e)


if __name__ == '__main__':
    broker="255.255.255.255" #ToDo: set IP
    port=8080 #ToDo: set port

    client = Client(client_id = "rasp-3")
    client.username_pw_set(username="mmr",password="diletta") #Todo: set username and password
    client.on_connect = on_connect
    try:
        client.connect(broker,port)
    except Exception as e:
        logging.error(e)

    start_daemon(client)