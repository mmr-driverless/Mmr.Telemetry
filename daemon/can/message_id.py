
from enum import IntEnum


class MessageId:
  class S(IntEnum):
    ppa = 0
    lv12 = 1
    lv24 = 2
    pf = 3
    frbps = 4
    ebs = 5
    apps = 6
    tps = 7
    clutch = 8
  
  class AS(IntEnum):
    r2d = 32
    ts = 33
    finished = 34
    emergency = 35
    ready = 36
    driving = 37
    off = 38

  class MM(IntEnum):
    manual = 64
    idle = 65

  class AM(IntEnum):
    acceleration = 96
    skidpad = 97
    autocross = 98
    trackdrive = 99
    ebs_test = 100
    inspection = 101

  class AMC(IntEnum):
    mission_finished = 128
    vehicle_standstill = 129
    mission_selected = 130
    asms = 131
    asb = 132
    ts = 133
    be = 134

  class D(IntEnum):
    steering_angle = 160
    braking_percentage = 161
    accelerator_percentage = 162
    speed_odometry = 163

  class ECU(IntEnum):
    pedal_throttle = 192
    temperatures = 193
    engine_fn1 = 194
    pressures = 195
    engine_fn2 = 196
    fb_pit_launch = 197
    wheel_speeds = 198

  class CS(IntEnum):
    clutch_signal = 224
    clutch_feedback = 225

  class ST(IntEnum):
    proportional_error_left_x = 256
    proportional_error_right_x = 257
    proportional_odometry_min_speed_left_x = 258
    proportional_odometry_min_speed_left_y = 259
    proportional_odometry_min_speed_right_x = 260
    proportional_odometry_min_speed_right_y = 261
    proportional_odometry_max_speed_left_y = 262
    proportional_odometry_max_speed_right_y = 263
    rise_cutoff_frequency = 264
    steering_center_autoset = 265
    steering_center_autoset_ok = 266
    current_angle = 267
