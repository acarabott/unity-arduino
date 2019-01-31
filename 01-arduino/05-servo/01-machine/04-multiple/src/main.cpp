#include <Arduino.h>
#include <Servo.h>

// Servo basics

// Topics
// - multiple servos

const int servoPinA = 3; // pwm pin
const int servoPinB = 5; // pwm pin

Servo servoA;
Servo servoB;

void setup() {
  servoA.attach(servoPinA);
  servoB.attach(servoPinB);
}

void loop() {
  // All at once
  // -----------
  servoA.write(0);
  servoB.write(0);
  delay(1000);

  servoA.write(180);
  servoB.write(180);
  delay(1000);


  // Staggered
  // ---------
  servoA.write(0);
  servoB.write(0);
  delay(1000);

  servoA.write(180);
  delay(250);

  servoB.write(180);
  delay(250);

  delay(1000);
}
