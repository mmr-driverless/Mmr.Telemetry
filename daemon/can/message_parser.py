import struct
from daemon.can.messages_map import MESSAGES_MAP


class MessageParser:
  @staticmethod
  def parse(id: int, message: bytes):
    format = MESSAGES_MAP[id]
    result = struct.unpack(format, message)
    return result