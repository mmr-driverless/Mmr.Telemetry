#!/usr/bin/python3

import json
import logging
import can
import paho.mqtt.client as Client
from daemon.can.message_parser import MessageParser

from daemon.mqtt.enums.connection_status import ConnectionStatus


def on_connect(client, userdata, flags, rc):
  if rc == ConnectionStatus.SUCCESS:
    logging.info('Connected to mqtt server')
  else:
    logging.error('Could not connect to the mqtt server', rc)


def run_daemon(client):
  with create_bus() as bus:
    bus.state = can.bus.PASSIVE
    try:
      while True:
        msg = bus.recv(1)
        if msg is None:
          continue

        logging.info(f'{msg.arbitration_id:X}: {msg.data}')

        topic = f'mmr/telemetry/{msg.arbitration_id}'
        data = MessageParser.parse(msg.arbitration_id, msg.data)
        client.publish(topic, json.dumps(data))

    except Exception as e:
      logging.error(e)


def create_bus():
  return can.interface.Bus(
    interface='socketcan',
    channel='can0', 
    bitrate=1000000,
  )


def create_client():
  broker = '255.255.255.255'
  port = 8080

  client = Client(client_id = 'mmr_daemon')
  client.on_connect = on_connect
  client.connect(broker, port)
  return client


if __name__ == '__main__':
  with create_client() as client:
    run_daemon(client)