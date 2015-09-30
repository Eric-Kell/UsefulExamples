#include <iostream>
#include <stdio.h>

using namespace std;

int main()
{
	printf("hello world %d\n",5);
	cout << "hello world" << 5 << "\n" << endl;

	int* pointer = new int(5);
	cout << *pointer << endl;

	return 0;
}