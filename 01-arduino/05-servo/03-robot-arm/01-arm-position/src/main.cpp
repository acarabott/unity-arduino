#include <Arduino.h>
#include <Servo.h>
#include <getArmAngles.h>

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

  // this returns a struct, which is multiple pieces of data collected together
  // into a "data structure"
  const auto armAngles = getArmAngles(xPos, yPos, ARM_LENGTH);

  // access the pieces of data using the dot notation
  // open getArmAngles.h to see the data structure
  baseServo.write(armAngles.base);
  jointServo.write(armAngles.joint - JOINT_OFFSET_DEGREES);
}
