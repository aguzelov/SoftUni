#pragma once

#include <memory>

#include "Tool.h"
#include "BrushSettings.h"

template<typename PixelT> class Brush : public Tool<PixelT> {
	std::shared_ptr<BrushSettings<PixelT> > settings;
public:
	Brush() : Tool<PixelT>( "brush" ), settings( new BrushSettings<PixelT>() ) {}

	virtual void apply( Bitmap<PixelT>& matrix, int row, int col ) override {
		PixelT color = settings->getFillColor();
		int radius = settings->getRadius();
		int startRow = row-radius;
		int endRow = row+radius;
		int startCol = col-radius;
		int endCol = col+radius;
		
		if(startRow < 0)
		{
			for(int i = 0; i<=endRow; i++)
			{
				if(startCol < 0)
				{
					for(int j = 0; j<=endCol; j++)
					{
						matrix[i][j] = color;
					}
				}else
				{
					for(int j = startCol; j<=endCol; j++)
					{
						matrix[i][j] = color;
					}
				}
			}
		}else
		{
			for(int i = startRow; i<=endRow; i++)
			{
				if(startCol < 0)
				{
					for(int j = 0; j<=endCol; j++)
					{
						matrix[i][j] = color;
					}
				} else
				{
					for(int j = startCol; j<=endCol; j++)
					{
						matrix[i][j] = color;
					}
				}
			}
		}
		
	}


	virtual SettingsPtr<PixelT> getSettings() override {
		return this->settings;
	}
};
