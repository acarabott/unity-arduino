#include <Arduino.h>
#include <Servo.h>
#include "../../getArmAngles.h"

// Drawing a circle in the air with the robot arm

// Topics
// - including a custom library

const float ARM_LENGTH = 11.0f;
const float JOINT_OFFSET_DEGREES = 30.0f;

const int baseServoPin = 3;
Servo baseServo;

const int jointServoPin = 5;
Servo jointServo;

const float radius = 5.0f;
const int offsetX = 10;
const int offsetY = 10;
const int waitMs = 3 * 1000 / 360;

int theta = 0;

void setup() {
  baseServo.attach(baseServoPin);
  jointServo.attach(jointServoPin);

  Serial.begin(9600);
}

void loop() {
  const float xPos = offsetX + cosf(theta * DEG_TO_RAD) * radius;
  const float yPos = offsetY + sinf(theta * DEG_TO_RAD) * radius;

  const auto armAngles = getArmAngles(xPos, yPos, ARM_LENGTH);

  baseServo.write(armAngles.base);
  jointServo.write(armAngles.joint - JOINT_OFFSET_DEGREES);

  theta += 1;

  if (theta > 360) {
    theta = 0;
  }

  delay(waitMs);
}
