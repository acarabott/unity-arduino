#include <Arduino.h>
#include <Servo.h>

// Controlling a servo with a photoresistor

// Topics
// - constrain
// - smoothing signals
// - float

// Challenges
// - adapt for two servos and photoresistors

const int servoPin = 3; // pwm pin
Servo servo;

const int photoPin = A5;

int prevDegrees = 0;
float smoothing = 0.8;

void setup() {
  servo.attach(servoPin);
  pinMode(photoPin, INPUT);

  Serial.begin(9600);
}

void loop() {
  const int inValue = analogRead(photoPin);

  const int inMin = 50;
  const int inMax = 360;

  const int degreesMin = 180;
  const int degreesMax = 0;

  const int inConstrained = constrain(inValue, inMin, inMax);
  const int mappedDegrees = map(inConstrained, inMin, inMax, degreesMin, degreesMax);

  // white board through this maths
  const int degrees = (smoothing * prevDegrees) + ((1 - smoothing) * mappedDegrees);

  servo.write(degrees);

  prevDegrees = degrees;


  Serial.print("input: ");
  Serial.print(inValue);

  Serial.print(" - ");

  Serial.print("degrees: ");
  Serial.print(degrees);

  Serial.println("");

  // challenge, control the amount of smoothing using a potentiometer
}
