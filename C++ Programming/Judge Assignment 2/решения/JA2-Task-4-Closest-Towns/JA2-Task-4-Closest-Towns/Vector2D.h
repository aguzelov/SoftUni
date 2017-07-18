#ifndef VECTOR_2D
#define VECTOR_2D

#include<cmath>

class Vector2D {
protected:
    double x;
    double y;
public:
    Vector2D() :
        x(0),
        y(0) {
    }

    Vector2D(double x, double y) :
        x(x),
        y(y) {
    }

    Vector2D operator+(const Vector2D & other) const {
        return Vector2D(this->x + other.x, this->y + other.y);
    }

    Vector2D operator-(const Vector2D & other) const {
        return Vector2D(this->x - other.x, this->y - other.y);
    }

    double getLength() const {
        return sqrt(getLengthSq());
    }

    double getLengthSq() const {
        return this->x * this->x + this->y * this->y;
    }
};

#endif // VECTOR_2D
