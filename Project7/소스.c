#include <stdio.h>
int n, m;      //2���� �迭�� �Ű������� �������� ���ΰ��� �Է������ �ϹǷ� ��������
void input_score();
void output();
void output_menu();
void reset();


int main()
{

	printf("�л� ���� ���� ���� �Է��ϼ���.\n");
	scanf_s("%d %d", &n, &m);

	int student_arr[n + 1][m + 1];
	reset(student_arr, n, m);

	input_score(student_arr, n, m);

	output_menu(m);
	output(student_arr, n, m);

	return 0;

}





void output_menu(int m) {
	int i;
	printf("          ");
	for (i = 0; i < m; i++) {
		printf("%2d���� ", i + 1);
	}
	printf("  ����");
	printf("\n");

}


void output(int stu_arr[][m + 1], int n, int m) {

	int i, j;

	for (i = 0; i < n; i++) {
		printf("%2d�� �л� ", i + 1);

		for (j = 0; j <= m; j++) {
			printf(" %5d ", stu_arr[i][j]);
		}
		printf("\n");
	}
	printf("     ���� ");
	for (i = 0; i < m; i++) {
		printf(" %5d ", stu_arr[n][i]);
	}
	printf("\n");
}


void reset(int arr[][m + 1], int n, int m) {
	int i;
	for (i = 0; i <= m; i++) {
		arr[n][i] = 0;
	}
	for (i = 0; i <= n; i++) {
		arr[i][m] = 0;
	}
}

void input_score(int stu_arr[][m + 1], int n, int m) {
	int i, j;

	printf("�� �л����� ���� ������� ������ �Է��ϼ���.\n");
	for (i = 0; i < n; i++) {
		printf("%d ��° �л� ", i + 1);
		for (j = 0; j < m; j++) {
			scanf_s("%d", &stu_arr[i][j]);
			stu_arr[i][m] += stu_arr[i][j];
			stu_arr[n][j] += stu_arr[i][j];
		}
	}

}
