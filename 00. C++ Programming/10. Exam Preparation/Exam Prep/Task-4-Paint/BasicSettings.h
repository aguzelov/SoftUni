#ifndef BASIC_SETTINGS_H
#define BASIC_SETTINGS_H

#include <sstream>
#include <string>

#include "Settings.h"

template<typename PixelT> class BasicSettings : public Settings<PixelT> {
    PixelT fillColor;
public:
    BasicSettings() = default;

    virtual void load(const std::string& settingsString) override {
        std::istringstream input(settingsString);

        input >> this->fillColor;
    }

    virtual PixelT getFillColor() {
        return this->fillColor;
    }
};

#endif // BASIC_SETTINGS_H
