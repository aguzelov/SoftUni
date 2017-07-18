/*
03
Write a void selectionSort(int a[], int start, int end) function that uses the selection sort algorithm to sort the elements from arr[start] to arr[end – 1] in increasing order (the elements outside the [start, end) range shouldn’t be sorted). This function modifies the array, so that the elements between start and end are sorted.
Selection sort: in this case it would just find the smallest element between start and end, and place it at the start, then find the next smallest between the remaining (aka start + 1 and end) and place it at the next position (aka start + 1) and so on
*/
/*Selection sort performs the following steps to sort an array from smallest to largest:
1) Starting at array index 0, search the entire array to find the smallest value
2) Swap the smallest value found in the array with the value at index 0
3) Repeat steps 1 & 2 starting from the next index*/

#include <iostream>
#include <algorithm>

int getInput(std::string text);
void checkInput(int& input);
void enterElementsInArray(int arr[], int length, std::string text);
void selectionSort(int a[], int start, int end);
void printElementsInArray(int arr[], int length);
void checkIndex(int &, int &, int);

int main() {
    int arrayLength = getInput("array length");
    int array[arrayLength];
    enterElementsInArray(array, arrayLength, "array element");

    int startIndex = 0 ;
    int endIndex= 0;
    checkIndex(startIndex, endIndex, arrayLength);

    selectionSort(array, startIndex, endIndex);

    printElementsInArray(array, arrayLength);
    return 0;
}
void checkIndex(int &start, int &end, int length){
    do{
        std::cout << "Index must be in range from 0 to " << length-1 << std::endl;
        start = getInput("start index");
        end = getInput("end index");
    }while((end > length-1) || (start > end));
}
void selectionSort(int a[], int start, int end) {
    for(int startIndex = start; startIndex < end ; startIndex++) {
        int smallestIndex = startIndex;
        for(int currentIndex = startIndex + 1; currentIndex <= end ; currentIndex++) {
            if(a[currentIndex] < a[smallestIndex]) {
                smallestIndex = currentIndex;
            }
        }
        std::swap(a[startIndex], a[smallestIndex]);
    }
}
void printElementsInArray(int arr[], int length) {
    for(int i = 0 ; i < length ; i++) {
        if(i == (length - 1)) {
            std::cout << arr[i] << std::endl;
        } else {
            std::cout << arr[i] << " ";
        }
    }
}
void enterElementsInArray(int arr[], int length, std::string text) {
    for(int i = 0; i < length ; i++) {
        std::cout<< "At index : " << i<< " . ";
        arr[i] = getInput(text);
    }
}
void checkInput(int& input) {
    while(!std::cin) {
        std::cout << "Bad input! Try again : ";
        std::cin.clear();
        std::cin.ignore(256, '\n');
        std::cin >> input;
    }
}
int getInput( std::string text) {
    int input;
    std::cout << "Enter " << text << ": " ;
    std::cin >> input;
    checkInput(input);
    return input;
}
