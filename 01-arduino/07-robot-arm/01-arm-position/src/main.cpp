#include <Arduino.h>
#include <Servo.h>

// Topics
// - structs
// - trig functions

const float ARM_LENGTH = 12.0f;
const float JOINT_OFFSET_DEGREES = 30.0f;

const int baseServoPin = 3;
Servo baseServo;

const int jointServoPin = 5;
Servo jointServo;

const int potPinX = A0;
const int potPinY = A1;

float xPos = 6.0f;
float yPos = 10.0f;

const float smoothing = 0.80f;

struct armAngles {
  float base;
  float joint;
};

armAngles getArmAngles(float xPos, float yPos, float armLength) {
  const float distanceToTarget = min(sqrtf(xPos * xPos + yPos * yPos), armLength * 2 * 0.95f);
  const float alpha = xPos == 0 ? 0 : atanf(yPos / xPos) * RAD_TO_DEG;
  const float beta = acosf(distanceToTarget / (2.0f * armLength)) * RAD_TO_DEG;

  struct armAngles angles = {
    .base = 180.0f - (alpha + beta),
    .joint = 180.0f - (2.0f * beta),
  };

  return angles;
}

void setup() {
  baseServo.attach(baseServoPin);
  jointServo.attach(jointServoPin);
}

void loop() {
  const int potValueX = analogRead(potPinX);
  const int potValueY = analogRead(potPinY);

  const int xPosNew = map(potValueX, 0, 1023, 0, ARM_LENGTH * 2);
  const int yPosNew = map(potValueY, 0, 1023, 0, ARM_LENGTH * 2);

  xPos = (xPos * smoothing) + ((1 - smoothing) * xPosNew);
  yPos = (yPos * smoothing) + ((1 - smoothing) * yPosNew);

  const auto armAngles = getArmAngles(xPos, yPos, ARM_LENGTH);

  baseServo.write(armAngles.base);
  jointServo.write(armAngles.joint - JOINT_OFFSET_DEGREES);
}
