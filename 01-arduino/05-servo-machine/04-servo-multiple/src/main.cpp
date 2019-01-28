#include <Arduino.h>
#include <Servo.h>

// Servo basics

// Topics
// - multiple servos

const int servoPinA = 3; // pwm pin
const int servoPinB = 5; // pwm pin
const int servoPinC = 9; // pwm pin

Servo servoA;
Servo servoB;
Servo servoC;

void setup() {
  servoA.attach(servoPinA);
  servoB.attach(servoPinB);
  servoC.attach(servoPinC);
}

void loop() {
  // All at once
  // -----------
  servoA.write(0);
  servoB.write(0);
  servoC.write(0);
  delay(1000);

  servoA.write(180);
  servoB.write(180);
  servoC.write(180);
  delay(1000);


  // Staggered
  // ---------
  servoA.write(0);
  servoB.write(0);
  servoC.write(0);
  delay(1000);

  servoA.write(180);
  delay(250);

  servoB.write(180);
  delay(250);

  servoC.write(180);
  delay(250);

  delay(1000);
}
