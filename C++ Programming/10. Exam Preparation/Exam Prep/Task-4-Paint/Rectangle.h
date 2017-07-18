#pragma once

#include <memory>

#include "Tool.h"
#include "BasicSettings.h"

template<typename PixelT> class Rectangle : public Tool<PixelT> {
	std::shared_ptr<BasicSettings<PixelT>> settings;
	int prevRow = 0, prevCol = 0;
	bool isUsed = false;
public:
	Rectangle() : Tool<PixelT>( "rect" ), settings( new BasicSettings<PixelT>() ) {}

	virtual void apply( Bitmap<PixelT>& matrix, int row, int col ) override {
		PixelT color = settings->getFillColor();
		if(isUsed == false)
		{
			this->prevRow = row;
			this->prevCol = col;
			this->isUsed = true;
		}else{
			int startRow = row<prevRow ? row : prevRow;
			int endRow = row<prevRow ? prevRow : row;
			int startCol = col<prevCol ? col : prevCol;
			int endCol = col<prevCol ? prevCol : col;
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
			this->isUsed = false;
		}
		
	}


	virtual SettingsPtr<PixelT> getSettings() override {
		return this->settings;
	}
};