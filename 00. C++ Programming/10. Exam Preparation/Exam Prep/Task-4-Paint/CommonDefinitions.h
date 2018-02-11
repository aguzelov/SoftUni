#include <vector>
#include <memory>
#include <algorithm>

template<typename PixelT> class Tool;
template<typename PixelT> class Settings;

template<typename PixelT> using ToolPtr = std::shared_ptr<Tool<PixelT> >;
template<typename PixelT> using SettingsPtr = std::shared_ptr<Settings<PixelT> >;

template<typename PixelT> using PixelRow = std::vector<PixelT>;
template<typename PixelT> using Bitmap = std::vector<PixelRow<PixelT> >;
