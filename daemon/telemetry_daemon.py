#!/usr/bin/python3

from enum import IntEnum
import logging
import can
import paho.mqtt.client as Client


class ConnectionStatus(IntEnum):
  SUCCESS = 0
  INCORRECT_PROTOCOL = 1
  INVALID_CLIENT_ID = 2
  SERVER_UNAVAILABLE = 3
  BAD_CREDENTIALS = 4
  NOT_AUTORIZED = 5


def on_connect(client, userdata, flags, rc):
  if rc == ConnectionStatus.SUCCESS:
    logging.info('CONNECTED - Returned code=', rc)
  else:
    logging.info('Bad connection - Returned code=', rc)


'''
Simply check the bus each loop and redirect messages on a topic 
based on their can_id.
'''
def start_daemon(client):
  with create_bus() as bus:
    # set to read-only, only supported on some interfaces
    bus.state = can.bus.PASSIVE

    try:
      while True:
        msg = bus.recv(1)
        if msg is not None:
          logging.info(f'{msg.arbitration_id:X}: {msg.data}')

          topic = f'mmr/telemetry/raw/{msg.arbitration_id}'
          data = msg.data
          client.publish(topic, data) # If more reliability is necessary use 1 or 2 for QoS (3rd parameter, default = 0)

    except Exception as e:
      logging.error(e)


def create_bus():
  return can.interface.Bus(
    interface='socketcan',
    channel='can0', 
    bitrate=1000000,
  )


if __name__ == '__main__':
  broker = '255.255.255.255' #ToDo: set IP
  port = 8080 #ToDo: set port

  client = Client(client_id = 'rasp-3')
  #Todo: set username and password
  client.username_pw_set(
    username='mmr',
    password='diletta',
  )
  
  client.on_connect = on_connect
  try:
    client.connect(broker,port)
  except Exception as e:
    logging.error(e)

  start_daemon(client)