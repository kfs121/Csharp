#include<stdio.h>
int main(void) {
	int a, b;
	char op;
	printf("수식을 입력하시오: ");
	scanf_s("%d %c %d", &a, &op, &b);
	if (op == '+') {
		printf("%d", a + b);
	}
	else if (op == '-') {
		printf("%d", a - b);
	}
	else if (op == '*') {
		printf("%d", a * b);
	}
	else if (op == '/') {
		printf("%d", a / b);
	}
	else {
		printf("지원하지 않는 연산자입니다");
	}
	return 0;
}