#include <Arduino.h>
#include <ArduinoJson.h>
#include <Servo.h>

const int baseServoPin = 3;
Servo baseServo;
int baseAngle = 90;

const int jointServoPin = 5;
Servo jointServo;
int jointAngle = 90;

void setup() {
  Serial.begin(115200);
  baseServo.attach(baseServoPin);
  jointServo.attach(jointServoPin);
}

void loop() {
  ArduinoJson::StaticJsonBuffer<200> jsonBuffer;
  ArduinoJson::JsonObject& obj = jsonBuffer.parseObject(Serial);

  if (obj.success()) {
    baseAngle = constrain(obj["baseAngle"], 0, 180); // never trust your input values
    jointAngle = constrain(obj["jointAngle"], 0, 180); // never trust your input values

    // use the builtin LED for debugging
    digitalWrite(LED_BUILTIN, HIGH);
  }
  else {

    digitalWrite(LED_BUILTIN, LOW);
  }

  baseServo.write(baseAngle);
  jointServo.write(jointAngle);
}
