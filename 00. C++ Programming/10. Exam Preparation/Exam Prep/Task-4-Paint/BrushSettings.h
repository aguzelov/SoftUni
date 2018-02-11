#pragma once
#include <sstream>
#include <string>

#include "Settings.h"

template<typename PixelT> class BrushSettings : public Settings<PixelT> {
	PixelT fillColor;
	int radius = 0;
public:
	BrushSettings() = default;

	virtual void load( const std::string& settingsString ) override {
		std::istringstream input( settingsString );
		
		input>>this->fillColor >> this->radius;
	}

	virtual int getRadius () const
	{
		return this->radius;
	}
	virtual PixelT getFillColor() {
		return this->fillColor;
	}
};