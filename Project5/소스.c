#include <stdio.h>


int main()
{
	char word[10];
	int i;
	for (i = 0; i < 10; i++) {
		scanf_s(" %c", &word[i]);
	}

	for (i = 0; i < 10; i++) {
		printf("%c", word[i]);
	}
	return 0;
}
