#ifndef TOOL_H
#define TOOL_H

#include "CommonDefinitions.h"

#include "Settings.h"

template<typename PixelT> class Tool {
    std::string id;
public:
    Tool(std::string id) : id{id} {}

    std::string getId() {
        return this->id;
    }

    virtual void apply(Bitmap<PixelT>& matrix, int row, int col) = 0;
    virtual SettingsPtr<PixelT> getSettings() = 0;

    Tool(const Tool<PixelT>& other) = default;
    Tool(Tool<PixelT>&& other) = default;
    virtual Tool<PixelT>& operator=(const Tool<PixelT>& other) = default;
    virtual Tool<PixelT>& operator=(Tool<PixelT>&& other) = default;
    virtual ~Tool() = default;
};

#endif // TOOL_H
