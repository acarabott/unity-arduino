#include <Arduino.h>
#include <Servo.h>

// Moving a servo at different speeds

// Topics
// - for loop

const int servoPin = 3;

Servo servo;

void setup() {
  servo.attach(servoPin);
}

void loop() {
  const int delayTimeMs = 10;

  // speed control
  // -------------
  for(int i = 0; i < 180; i++)
  {
    servo.write(i);
    delay(delayTimeMs);
  }

  for(int i = 180; i > 0; i--)
  {
    servo.write(i);
    delay(delayTimeMs);
  }

  // challenge
  // ---------
  // const int durationMs = 5 * 1000;
  // const int startPosition = 45;
  // const int stopPosition = 180;
  // const int stepDelayMs = durationMs / (stopPosition - startPosition);

  // for(int i = startPosition; i < stopPosition; i++)
  // {
  //   servo.write(i);
  //   delay(stepDelayMs);
  // }
}
