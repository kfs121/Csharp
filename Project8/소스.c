#include<stdio.h>
int main(void) {
	int a, b;
	char op;
	printf("������ �Է��Ͻÿ�: ");
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
		printf("�������� �ʴ� �������Դϴ�");
	}
	return 0;
}