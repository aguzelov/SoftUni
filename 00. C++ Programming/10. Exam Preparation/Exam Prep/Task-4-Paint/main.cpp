#include <iostream>
#include <sstream>
#include <string>

#include "CommonDefinitions.h"
#include "PaintEngine.h"
#include "Tool.h"
#include "ToolFactory.h"

const int Rows = 20;
const int Cols = 50;

template<typename PixelT> void test(PixelT);

int main() {
    std::string testType;
    std::getline(std::cin, testType);

    if (testType == "char") {
        test<char>(' ');
    } else if (testType == "hex") {
        test<std::string>("#000000");
    }
	system( "PAUSE" );
}

template<typename PixelT> void test(PixelT defaultFill) {
    PaintEngine<PixelT> engine(Rows, Cols, defaultFill);

    std::string line;
    std::getline(std::cin, line);
    while (line != "end") {
        std::istringstream lineStream(line);

        std::string command;
        std::string toolId;
        lineStream >> command >> toolId;

        if (command == "use") {
            int row, col;
            lineStream >> row >> col;
            engine.useTool(toolId, row, col);
        } else if (command == "configure") {
            SettingsPtr<PixelT> toolSettings = engine.getSettings(toolId);

            if(!toolSettings) {
                ToolPtr<PixelT> tool = ToolFactory::createTool<PixelT>(toolId);
                engine.addTool(tool);
                toolSettings = tool->getSettings();
            }

            std::string settingsStr(std::istreambuf_iterator<char>(lineStream), {});
            toolSettings->load(settingsStr);
        }
		system( "cls" );
		std::cout<<engine.getMatrixString();

        std::getline(std::cin, line);
    }

    std::cout << engine.getMatrixString();
}
