#include <Arduino.h>
#include <Servo.h>

// Servo basics

// Topics
// - arrays
// - macros
// - size_t

#define countof(Array) (sizeof(Array) / sizeof(Array[0]))

const int servoPin = 3;
const int positions[] = { 0, 20, 45, 90, 180 };

Servo servo;

void setup() {
  servo.attach(servoPin);
}

void loop() {
  for(size_t i = 0; i < countof(positions); i++)
  {
    servo.write(positions[i]);
    delay(500);
  }
}
