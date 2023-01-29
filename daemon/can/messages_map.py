from daemon.can.message_id import MessageId


MESSAGES_MAP = {
  MessageId.S.pf: 'h',
  MessageId.S.frbps: 'f',
  MessageId.S.ebs: '?',
  MessageId.S.apps: 'h',
  MessageId.S.clutch: 'h',

  MessageId.AS.r2d: '?',
  MessageId.AS.ts: '?',
  MessageId.AS.finished: '?',
  MessageId.AS.emergency: '?',
  MessageId.AS.ready: '?',
  MessageId.AS.driving: '?',
  MessageId.AS.off: '?',

  MessageId.MM.manual: '?',
  MessageId.MM.idle: '?',

  MessageId.AM.acceleration: '?',
  MessageId.AM.skidpad: '?',
  MessageId.AM.autocross: '?',
  MessageId.AM.trackdrive: '?',
  MessageId.AM.ebs_test: '?',
  MessageId.AM.inspection: '?',

  MessageId.AMC.mission_finished: '?',
  MessageId.AMC.vehicle_standstill: '?',
  MessageId.AMC.mission_selected: '?',
  MessageId.AMC.asms: '?',
  MessageId.AMC.asb: '?',
  MessageId.AMC.ts: '?',
  MessageId.AMC.be: '?',

  MessageId.D.steering_angle: 'f',
  MessageId.D.braking_percentage: 'f',
  MessageId.D.accelerator_percentage: 'b',
  MessageId.D.speed_odometry: 'f',

  MessageId.ECU.pedal_throttle: '<hhhh',
  MessageId.ECU.temperatures: '<hhhh',
  MessageId.ECU.engine_fn1: '<hhhh',
  MessageId.ECU.pressures: '<hhhh',
  MessageId.ECU.engine_fn2: '<hhh',
  MessageId.ECU.fb_pit_launch: '<bb',
  MessageId.ECU.wheel_speeds: '<hhhh',

  MessageId.CS.clutch_signal: '?',
  MessageId.CS.clutch_feedback: '?',

  MessageId.ST.proportional_error_left_x: 'f',
  MessageId.ST.proportional_error_right_x: 'f',
  MessageId.ST.proportional_odometry_min_speed_left_x: 'f',
  MessageId.ST.proportional_odometry_min_speed_left_y: 'i',
  MessageId.ST.proportional_odometry_min_speed_right_x: 'f',
  MessageId.ST.proportional_odometry_min_speed_right_y: 'i',
  MessageId.ST.proportional_odometry_max_speed_left_y: 'i',
  MessageId.ST.proportional_odometry_max_speed_right_y: 'i',
  MessageId.ST.rise_cutoff_frequency: 'f',
  MessageId.ST.current_angle: 'f',
}
