#ifndef PAINT_ENGINE_H
#define PAINT_ENGINE_H

#include "CommonDefinitions.h"

#include <map>
#include <vector>
#include <memory>
#include <string>
#include <algorithm>

template<typename PixelT> class PaintEngine {
    size_t cols;
    Bitmap<PixelT> matrix;

    std::map<std::string, ToolPtr<PixelT> > tools;
public:
    PaintEngine(size_t rows, size_t cols, PixelT defaultFill) : cols(cols) {
        for (size_t r = 0; r < rows; r++) {
            PixelRow<PixelT> row;
            for (size_t c = 0; c < cols; c++) {
                row.push_back(defaultFill);
            }

            matrix.push_back(row);
        }
    }

    void addTool(const ToolPtr<PixelT>& tool) {
        this->tools[tool->getId()] = tool;
    }

    SettingsPtr<PixelT> getSettings(std::string toolId) {
        auto tool = getTool(toolId);
        if (tool) {
            return tool->getSettings();
        }

        return nullptr;
    }

    void useTool(std::string toolId, int row, int col) {
        auto tool = getTool(toolId);
        if (tool) {
            tool->apply(matrix, row, col);
        }
    }

    std::string getMatrixString() {
        std::ostringstream s;

        for (size_t r = 0; r < this->matrix.size(); r++) {
            for (size_t c = 0; c < this->cols; c++) {
                s << matrix[r][c];
            }
            s << std::endl;
        }

        return s.str();
    }
private:
    void ensureInBounds(size_t row, size_t col) {
        if (row < 0 || row >= matrix.size() || col < 0 || col >= this->cols) {
            throw std::range_error("bitmap position out of bounds");
        }
    }

    ToolPtr<PixelT> getTool(std::string toolId) {
        auto toolIter = this->tools.find(toolId);
        if (toolIter != tools.end()) {
            return toolIter->second;
        }

        return ToolPtr<PixelT>(nullptr);
    }
};

#endif // PAINT_ENGINE_H
