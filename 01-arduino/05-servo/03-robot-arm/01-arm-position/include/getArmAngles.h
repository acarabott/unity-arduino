#include <Arduino.h>

struct armAngles {
  float base;
  float joint;
};

armAngles getArmAngles(float xPos, float yPos, float armLength) {
  const float distanceToTarget = min(sqrtf(xPos * xPos + yPos * yPos), armLength * 2 * 0.95f);
  const float alpha = xPos == 0 ? 0 : atanf(yPos / max(xPos, 0.001)) * RAD_TO_DEG;
  const float beta = acosf(distanceToTarget / (2.0f * armLength)) * RAD_TO_DEG;

  struct armAngles angles = {
    .base = alpha + beta,
    .joint = 180.0f - (2.0f * beta),
  };

  return angles;
}
