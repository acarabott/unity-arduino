#include <Arduino.h>
#include <Servo.h>

// Controlling a servo with a potentiometer

// Topics
// - printing debug information
// - good vs bad mapping

const int servoPin = 3; // pwm pin
Servo servo;

const int potPin = A0;

void setup() {
  servo.attach(servoPin);
  pinMode(potPin, INPUT);

  Serial.begin(9600);
}

void loop() {
  const int potValue = analogRead(potPin);

  const int inMin = 0;
  const int inMax = 1023;

  // Show how quality of the mapping changes if you flip these
  // or even just turn the servo to face the opposite direction
  const int degreesMin = 0;
  const int degreesMax = 180;

  const int degrees = map(potValue, inMin, inMax, degreesMin, degreesMax);
  servo.write(degrees);


  Serial.print("input: ");
  Serial.print(potValue);

  Serial.print(" - ");

  Serial.print("degrees: ");
  Serial.print(degrees);

  Serial.println("");
}
