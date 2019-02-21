#include <Arduino.h>
#include <ArduinoJson.h>
#include <Servo.h>

const int ledPin = 10;
int led = 255;

const int baseServoPin = 5;
Servo baseServo;
int baseAngle = 65;

const int jointServoPin = 6;
Servo jointServo;
int jointAngle = 90;

void setup() {
  Serial.begin(115200);
  baseServo.attach(baseServoPin);
  jointServo.attach(jointServoPin);
  pinMode(ledPin, OUTPUT);
}

void loop() {
  ArduinoJson::StaticJsonBuffer<200> jsonBuffer;
  ArduinoJson::JsonObject& obj = jsonBuffer.parseObject(Serial);

  if (obj.success()) {
    baseAngle = constrain(obj["baseAngle"], 0, 180); // never trust your input values
    jointAngle = constrain(obj["jointAngle"], 0, 180); // never trust your input values
    led = constrain(obj["led"], 0, 255); // never trust your input values


    // use the builtin LED for debugging
    digitalWrite(LED_BUILTIN, HIGH);
  }
  else {

    digitalWrite(LED_BUILTIN, LOW);
  }

  baseServo.write(baseAngle);
  jointServo.write(jointAngle);
  analogWrite(ledPin, led);
}
