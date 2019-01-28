#include <Arduino.h>
#include <ArduinoJson.h>



int state = LOW;
void setup() {
  Serial.begin(9600);
  pinMode(13, OUTPUT);
}

void loop() {
  ArduinoJson::StaticJsonBuffer<200> jsonBuffer;

  ArduinoJson::JsonObject& obj = jsonBuffer.parseObject(Serial);
  if (obj.success()) {
    float y = obj["y"];
    state = y > 5 ? 1 : 0;

    // Serial.println("yesyesyesyesyes");
    // state = abs(state - 1);
  }
  digitalWrite(13, state);


    // float x = obj["x"];
    // float y = obj["y"];
    // if (obj.containsKey("x")) {
    //   Serial.println("yesyesyesyesyes");
    //   digitalWrite(13, HIGH);
    // }
    // else {
    //   Serial.println(read);
    //   digitalWrite(13, LOW);
    // }

    // String msg = "y value: " + String(y);
    // Serial.println(msg);
    // digitalWrite(13, y > 5.0f ? HIGH : LOW);
  // }


}