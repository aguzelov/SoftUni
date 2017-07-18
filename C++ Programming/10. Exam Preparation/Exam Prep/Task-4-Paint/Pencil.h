#ifndef PENCIL_H
#define PENCIL_H

#include <memory>

#include "Tool.h"
#include "BasicSettings.h"

template<typename PixelT> class Pencil : public Tool<PixelT> {
    SettingsPtr<PixelT> settings;
public:
    Pencil() : Tool<PixelT>("pencil"), settings(new BasicSettings<PixelT>()) {}

    virtual void apply(Bitmap<PixelT>& matrix, int row, int col) override {
        matrix[row][col] = ((BasicSettings<PixelT>&)(*settings)).getFillColor();
    }

    virtual SettingsPtr<PixelT> getSettings() override {
        return this->settings;
    }
};

#endif // PENCIL_H
