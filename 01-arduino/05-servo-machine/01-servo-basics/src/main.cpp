#include <Arduino.h>
#include <Servo.h> // show autocomplete, command click

// Servo basics

// Topics
// - including a library
// - using the servo library


const int servoPin = 3; // pwm pin
Servo servo;

void setup() {
  servo.attach(servoPin);
}

void loop() {
  servo.write(0);
  delay(1000);

  servo.write(180);
  delay(1000);
}
