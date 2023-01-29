
from enum import IntEnum


class ConnectionStatus(IntEnum):
  SUCCESS = 0
  INCORRECT_PROTOCOL = 1
  INVALID_CLIENT_ID = 2
  SERVER_UNAVAILABLE = 3
  BAD_CREDENTIALS = 4
  NOT_AUTORIZED = 5
