#ifndef FIGURE_H
#define FIGURE_H
#include <iostream>
#include <string>
#include <sstream>
#include <vector>
using std::cout;
using std::endl;
using std::string;

enum FigureColor{
	noneColor,
	white,
	black
};
enum FigureSymbol{
	noneSymbol,
	pawn,
	knight,
	bishop,
	rook,
	queen,
	king
};

class Figure{
public:
	FigureSymbol symbol;
	FigureColor color;
	int x = 0;
	int y = 0;
	static int board[8][8][3] ;
	std::vector<string> availableMove;

	Figure(FigureSymbol symbol, FigureColor color, std::string position) : 
		symbol(symbol), 
		color(color){

		setPosition(position);
		setBoard(this->x, this->y, this->symbol, this->color);
	}
	int getSymbol(){
		return static_cast<FigureSymbol>(symbol);
	}
	int getColor(){
		return static_cast<FigureColor>(color);
	}
	int getXFromString(std::string pos){
		int x = 0;
		switch (pos[0])
		{
		case 'A': x = 0; break;
		case 'B': x = 1; break;
		case 'C': x = 2; break;
		case 'D': x = 3; break;
		case 'E': x = 4; break;
		case 'F': x = 5; break;
		case 'G': x = 6; break;
		case 'H': x = 7; break;
		default:
			break;
		}
		return x;
	}
	int getYFromString(std::string pos){
		int y = 0;
		std::stringstream stream;
		stream << pos[1];
		stream >> y;
		--y;
		return y;
	}

	void setPosition(std::string pos){
		switch (pos[0])
		{
		case 'A': x = 0; break;
		case 'B': x = 1; break;
		case 'C': x = 2; break;
		case 'D': x = 3; break;
		case 'E': x = 4; break;
		case 'F': x = 5; break;
		case 'G': x = 6; break;
		case 'H': x = 7; break;
		default:
			break;
		}

		std::stringstream stream;
		stream << pos[1];
		stream >> y;
		--y;
	}
	string convertPos(int x, int y){
		std::stringstream stream;

		switch (x)
		{
		case 0: stream << "A"; break;
		case 1: stream << "B"; break;
		case 2: stream << "C"; break;
		case 3: stream << "D"; break;
		case 4: stream << "E"; break;
		case 5: stream << "F"; break;
		case 6: stream << "G"; break;
		case 7: stream << "H"; break;
		default: 
			break;
		}
		stream << (y + 1);
		return stream.str();
	}
	void setBoard(int x, int y, FigureSymbol symbol, FigureColor color){
		board[this->x][this->y][0] = static_cast<FigureSymbol>(symbol);
		board[this->x][this->y][1] = x + y;
		board[this->x][this->y][2] = static_cast<FigureColor>(color);
	}

	bool ensureIndex(int newX, int newY, int oldX, int oldY){
		FigureColor otherColor = this->color == white ? black : white;

		if ((newX < 0 || newX >= 8) && (newY < 0 || newY >= 8)){
			return false;
		}
		if (this->color == white){
			
			if ((board[newX][newY][0] == noneSymbol) || (board[newX][newY][2] != white)){
				
				if (board[oldX][oldY][2] == otherColor){
					cout << "FALSE" << endl;
					return false;
				}
				return true;
			}
		}
		else if (this->color == black){
			if ((board[newX][newY][0] == noneSymbol) || (board[newX][newY][0] != black)){
				if (board[oldX][oldY][2] == otherColor){
					cout << "FALSE" << endl;
					return false;
				}
				return true;
			}
		}
		return false;
	}

	virtual void setAvailableMove(string newPos){
		
	}
	virtual bool move(std::string newPos){
		return 0;
	}
	void freePosition(string oldPos){
		for (int i = 0; i < 3; i++){
			board[getXFromString(oldPos)][getYFromString(oldPos)][i] = 0;
		}
	}
	std::vector<string> getAvailableMove(){

	}
};
int Figure::board[8][8][3] = { { { 0 } } };

class Pawn : public Figure{
public:
	Pawn(FigureColor color, string pos) :Figure(pawn, color, pos){
	}

	void setAvailableMove(string newPos){
		int x = getXFromString(newPos);
		int y = getYFromString(newPos);
		bool left, top, right, down;
		left = (x < this->x ? true : false);
		top = (y > this->y ? true : false);
		right = (x > this->x ? true : false);
		down = (y < this->y ? true : false);
		if (top){
			//top
			findAvailableMove(0, 1, 1);
		}
		else if (left || right || down){
		}
	}
	void findAvailableMove(int newX, int newY, int numberOfTitle){
		int currentX = this->x;
		int currentY = this->y;
		int oldX = this->x;
		int oldY = this->y;
		int counter = 0;
		if (this->color == white)
			while (ensureIndex(newX + currentX, newY + currentY, oldX, oldY) && counter < numberOfTitle){
		
				this->availableMove.push_back(convertPos(newX + currentX, currentY + newY));
				oldX = currentX;
				currentX -= newX;
				currentY += newY;
				counter++;
				
			}
		if (this->color == black)
			while (ensureIndex(newX - currentX, newY - currentY, oldX, oldY) && counter < numberOfTitle){
				
				this->availableMove.push_back(convertPos(newX - currentX, currentY - newY));
				oldX = currentX;
				currentX += newX;
				currentY -= newY;
				counter++;
				
			}
	}
	virtual bool move(std::string newPos){
		
				
		setAvailableMove(newPos);
		string oldPos = convertPos(this->x, this->y);
		for (int i = 0; i < availableMove.size(); i++){

			
			if (newPos == availableMove[i]){
				setPosition(availableMove[i]);
				setBoard(this->x, this->y, this->symbol, this->color);
				freePosition(oldPos);
				
				return true;
				
			}
		}
	
		return false;
	}
};
class Pawn1 :public Pawn{
public:
	Pawn1(FigureColor color) :Pawn(color, (color == white ? "A2" : "H6")){
	}
};
class Pawn2 :public Pawn{
public:
	Pawn2(FigureColor color) : Pawn(color, (color == white ? "B2" : "G6")){
	}
};
class Pawn3 :public Pawn{
public:
	Pawn3(FigureColor color) : Pawn(color, (color == white ? "C2" : "F6")) {
	}
};
class Pawn4 :public Pawn{
public:
	Pawn4(FigureColor color) :Pawn(color, (color == white ? "D2" : "E6")){
	}
};
class Pawn5 :public Pawn{
public:
	Pawn5(FigureColor color) : Pawn(color, (color == white ? "E2" : "D6")){
	}
};
class Pawn6 :public Pawn{
public:
	Pawn6(FigureColor color) : Pawn(color, (color == white ? "F2" : "C6")){
	}
};
class Pawn7 :public Pawn{
public:
	Pawn7(FigureColor color): Pawn(color, (color == white ? "G2" : "B6" )){
	}
};
class Pawn8 :public Pawn{
public:
	Pawn8(FigureColor color) : Pawn(color, (color == white ? "H2" : "A6")){
	}
}; 

class Knight : public Figure{
public:
	Knight(FigureColor color, std::string pos) : Figure(knight, color, pos){
	}
	void setAvailableMove(string newPos){
		int x = getXFromString(newPos);
		int y = getYFromString(newPos);
		bool left, top, right, down;
		left = (x < this->x? true : false);
		top = (y > this->y ? true : false);
		right = (x > this->x ? true : false);
		down = (y < this->y ? true : false);
		if (left){
			//left top
			findAvailableMove(-2, 1, 1);
			// left down
			findAvailableMove(-2, -1, 1);
		}
		else if (top){
			// top left
			findAvailableMove(-1, 2, 1);
			// top right
			findAvailableMove(1, 2, 1);
		}
		else if (right){
			// right top
			findAvailableMove(2, 1, 1);
			// right down
			findAvailableMove(2, -1, 1);
		}
		else if (down){
			// down left
			findAvailableMove(-1, -2, 1);
			// down right
			findAvailableMove(1, -2, 1);
		}
	}
	void findAvailableMove(int newX, int newY, int numberOfTitle){
		int currentX = this->x;
		int currentY = this->y;
		int oldX = this->x;
		int oldY = this->y;
		int counter = 0;
		if (this->color == white)
		while (ensureIndex(newX + currentX , newY + currentY, oldX, oldY) && counter < numberOfTitle){
			
			this->availableMove.push_back(convertPos(newX + currentX, currentY + newY));
			oldX = currentX;
			currentX -= newX;
			currentY += newY;
			counter++;
			
		}
		if (this->color == black)
			while (ensureIndex(newX - currentX, newY - currentY, oldX, oldY) && counter < numberOfTitle){
				
				this->availableMove.push_back(convertPos(newX - currentX, currentY - newY));
				oldX = currentX;
				currentX += newX;
				currentY -= newY;
				counter++;
				
			}
	}

	virtual bool move(std::string newPos){
		setAvailableMove(newPos);
		
		string oldPos = convertPos(this->x, this->y);
		for (int i = 0; i < availableMove.size(); i++){
			if (newPos == availableMove[i]){
				setPosition(availableMove[i]);
				setBoard(this->x, this->y, this->symbol, this->color);
				freePosition(oldPos);
				
				return true;

			}
		}
		
		return false;
	}
};
class KnightLeft : public Knight{
public:
	KnightLeft(FigureColor color) : Knight(color, (color == white ? "B1" : "G6")){
	}
};
class KnightRight : public Knight{
public:
	KnightRight(FigureColor color) : Knight(color, (color == white ? "G1" : "B8")){
	}
};

class Bishop : public Figure{
public:
	Bishop(FigureColor color, std::string pos) : Figure(bishop, color, pos){
	}
	void setAvailableMove(string newPos){
		int x = getXFromString(newPos);
		int y = getYFromString(newPos);
		bool left, top, right, down;
		left = (x < this->x ? true : false);
		top = (y > this->y ? true : false);
		right = (x > this->x ? true : false);
		down = (y < this->y ? true : false);
		if (top && left){
			//top left
			findAvailableMove(-1, 1, 8);
		}
		else if (top && right){
			// top right
			findAvailableMove(1, 1, 8);
		}
		else if (down && left){
			// down left
			findAvailableMove(-1, -1, 8);
		}
		else if (down && right){
			// down right
			findAvailableMove(1, -1, 8);
		}
	}
	void findAvailableMove(int newX, int newY, int numberOfTitle){
		int currentX = this->x;
		int currentY = this->y;
		int oldX = this->x;
		int oldY = this->y;
		int counter = 0;
		if (this->color == white)
			while (ensureIndex(newX + currentX, newY + currentY, oldX, oldY) && counter < numberOfTitle){
				
				this->availableMove.push_back(convertPos(newX + currentX, currentY + newY));
				oldX = currentX;
				currentX -= newX;
				currentY += newY;
				counter++;
				
			}
		if (this->color == black)
			while (ensureIndex(newX - currentX, newY - currentY, oldX, oldY) && counter < numberOfTitle){
				
				this->availableMove.push_back(convertPos(newY - currentX, currentY - newY));
				oldX = currentX;
				currentX += newX;
				currentY -= newY;
				counter++;
				
			}
	}
	virtual bool move(std::string newPos){
					
		setAvailableMove(newPos);
		string oldPos = convertPos(this->x, this->y);
		for (int i = 0; i < availableMove.size(); i++){
			if (newPos == availableMove[i]){
				setPosition(availableMove[i]);
				setBoard(this->x, this->y, this->symbol, this->color);
				freePosition(oldPos);
	
				return true;
			}
		}
		return false;
	}
};
class BishopLeft :public Bishop{
public:
	BishopLeft(FigureColor color) : Bishop(color,(color==white ? "C1" : "F8")){
	}
};
class BishopRight :public Bishop{
public:
	BishopRight(FigureColor color) : Bishop(color, (color == white ? "F1" : "C8")){
	}
};

class Rook : public Figure{
public:
	Rook(FigureColor color, std::string pos) : Figure(rook, color, pos){
	}
	void setAvailableMove(string newPos){
		int x = getXFromString(newPos);
		int y = getYFromString(newPos);
		bool left, top, right, down;
		left = (x < this->x ? true : false);
		top = (y > this->y ? true : false);
		right = (x > this->x ? true : false);
		down = (y < this->y ? true : false);
		if (top){
			//top left
			findAvailableMove(0, 1, 8);
		}
		else if (right){
			// top right
			findAvailableMove(1, 0, 8);
		}
		else if (left){
			// down left
			findAvailableMove(-1, 0, 8);
		}
		else if (down ){
			// down right
			findAvailableMove(0, -1, 8);
		}
	}
	void findAvailableMove(int newX, int newY, int numberOfTitle){
		int currentX = this->x;
		int currentY = this->y;
		int oldX = this->x;
		int oldY = this->y;
		int counter = 0;
		if (this->color == white)
			while (ensureIndex(newX + currentX, newY + currentY, oldX, oldY) && counter < numberOfTitle){
				
				this->availableMove.push_back(convertPos(newX + currentX, currentY + newY));
				oldX = currentX;
				currentX -= newX;
				currentY += newY;
				counter++;
				
			}
		if (this->color == black)
			while (ensureIndex(newX - currentX, newY - currentY, oldX, oldY) && counter < numberOfTitle){
				
				this->availableMove.push_back(convertPos(newY - currentX, currentY - newY));
				oldX = currentX;
				currentX += newX;
				currentY -= newY;
				counter++;
				
			}
	}
	virtual bool move(std::string newPos){
					
		setAvailableMove(newPos);
		string oldPos = convertPos(this->x, this->y);
		for (int i = 0; i < availableMove.size(); i++){
			if (newPos == availableMove[i]){
				setPosition(availableMove[i]);
				setBoard(this->x, this->y, this->symbol, this->color);
				freePosition(oldPos);
				
				return true;

			}
		}
		
		return false;
	}
};
class RookLeft: public Rook{
public:
	RookLeft(FigureColor color) : Rook(color, (color == white ? "A1" : "H8")){
	}
};
class RookRight : public Rook{
public:
	RookRight(FigureColor color) : Rook(color, (color == white ? "H1" : "A8")){
	}
};

class Queen : public Figure{
public:
	Queen(FigureColor color) : Figure(queen, color, (color == white ? "D1" : "D8")){
	}
	void setAvailableMove(string newPos){
		int x = getXFromString(newPos);
		int y = getYFromString(newPos);
		bool left, top, right, down;
		left = (x < this->x ? true : false);
		top = (y > this->y ? true : false);
		right = (x > this->x ? true : false);
		down = (y < this->y ? true : false);
		if (top){
			//top left
			findAvailableMove(0, 1, 8);
		}
		else if (right){
			// top right
			findAvailableMove(1, 0, 8);
		}
		else if (left){
			// down left
			findAvailableMove(-1, 0, 8);
		}
		else if (down){
			// down right
			findAvailableMove(0, -1, 8);
		}
		else if (top && left){
			// top left
			findAvailableMove(-1, 1, 8);
		}
		else if (top && right){
			// top right
			findAvailableMove(1, 1, 8);
		}
		else if (down && left){
			// down left
			findAvailableMove(-1, -1, 8);
		}
		else if (down && right){
			// down right
			findAvailableMove(1, -1, 8);
		}
	}
	void findAvailableMove(int newX, int newY, int numberOfTitle){
		int currentX = this->x;
		int currentY = this->y;
		int oldX = this->x;
		int oldY = this->y;
		int counter = 0;
		if (this->color == white)
			while (ensureIndex(newX + currentX, newY + currentY, oldX, oldY) && counter < numberOfTitle){
				
				this->availableMove.push_back(convertPos(newX + currentX, currentY + newY));
				oldX = currentX;
				currentX -= newX;
				currentY += newY;
				counter++;
				
			}
		if (this->color == black)
			while (ensureIndex(newX - currentX, newY - currentY, oldX, oldY) && counter < numberOfTitle){
				
				this->availableMove.push_back(convertPos(newX - currentX, currentY - newY));
				oldX = currentX;
				currentX += newX;
				currentY -= newY;
				counter++;
				
			}
	}
	virtual bool move(std::string newPos){
					
		setAvailableMove(newPos);
		string oldPos = convertPos(this->x, this->y);
		for (int i = 0; i < availableMove.size(); i++){
			if (newPos == availableMove[i]){
				setPosition(availableMove[i]);
				setBoard(this->x, this->y, this->symbol, this->color);
				freePosition(oldPos);
				
				return true;

			}
		}
		
		return false;
	}
};
class King : public Figure{
public:
	King(FigureColor color) : Figure(king, color, (color == white ? "E1" : "E8")){
	}
	void setAvailableMove(string newPos){
		int x = getXFromString(newPos);
		int y = getYFromString(newPos);
		bool left, top, right, down;
		left = (x < this->x ? true : false);
		top = (y > this->y ? true : false);
		right = (x > this->x ? true : false);
		down = (y < this->y ? true : false);
		if (top){
			//top left
			findAvailableMove(0, 1, 1);
		}
		else if (right){
			// top right
			findAvailableMove(1, 0, 1);
		}
		else if (left){
			// down left
			findAvailableMove(-1, 0, 1);
		}
		else if (down){
			// down right
			findAvailableMove(0, -1, 1);
		}
		else if (top && left){
			// top left
			findAvailableMove(-1, 1, 1);
		}
		else if (top && right){
			// top right
			findAvailableMove(1, 1, 1);
		}
		else if (down && left){
			// down left
			findAvailableMove(-1, -1, 1);
		}
		else if (down && right){
			// down right
			findAvailableMove(1, -1, 1);
		}
	}
	void findAvailableMove(int newX, int newY, int numberOfTitle){
		int currentX = this->x;
		int currentY = this->y;
		int oldX = this->x;
		int oldY = this->y;
		int counter = 0;
		if (this->color == white)
			while (ensureIndex(newX + currentX, newY + currentY, oldX, oldY) && counter < numberOfTitle){
				
				this->availableMove.push_back(convertPos(newX + currentX, currentY + newY));
				oldX = currentX;
				currentX -= newX;
				currentY += newY;
				counter++;
				
			}
		if (this->color == black)
			while (ensureIndex(newX - currentX, newY - currentY, oldX, oldY) && counter < numberOfTitle){
				
				this->availableMove.push_back(convertPos(newY - currentX, currentY - newY));
				oldX = currentX;
				currentX += newX;
				currentY -= newY;
				counter++;
				
			}
	}
	virtual bool move(std::string newPos){
					//newpos , left, top, right, down, numberOfTitle 
		setAvailableMove(newPos);
		string oldPos = convertPos(this->x, this->y);
		for (int i = 0; i < availableMove.size(); i++){
			if (newPos == availableMove[i]){
				setPosition(availableMove[i]);
				setBoard(this->x, this->y, this->symbol, this->color);
				freePosition(oldPos);
				
				return true;

			}
		}
		
		return false;
	}
};
#endif // !FIGURE_H