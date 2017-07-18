#ifndef SETTINGS_H
#define SETTINGS_H

#include <map>
#include <istream>
#include <string>

template<typename PixelT> class Settings {
public:
    Settings() = default;

    virtual void load(const std::string& settingsString) = 0;

    Settings(const Settings<PixelT>& other) = default;
    Settings(Settings<PixelT>&& other) = default;
    virtual Settings<PixelT>& operator=(const Settings<PixelT>& other) = default;
    virtual Settings<PixelT>& operator=(Settings<PixelT>&& other) = default;
    virtual ~Settings() = default;
};

#endif // SETTINGS_H
