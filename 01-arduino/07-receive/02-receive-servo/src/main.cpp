#include <Arduino.h>
#include <ArduinoJson.h>
#include <Servo.h>

const int servoPin = 3;
Servo servo;

void setup() {
  Serial.begin(9600);
  servo.attach(servoPin);
}

void loop() {
  ArduinoJson::StaticJsonBuffer<200> jsonBuffer;
  ArduinoJson::JsonObject& obj = jsonBuffer.parseObject(Serial);
  if (obj.success()) {
    const int servoAngle = constrain(obj["servoAngle"], 0, 180); // never trust your input values
    servo.write(servoAngle);
  }
}