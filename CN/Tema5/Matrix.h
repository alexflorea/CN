#include <stdio.h>
#include <stdlib.h>

class Matrix
{
public:
	Matrix(char*);
	
	void PrintMatrix();
	bool IsSymmetric();
	bool IsSquare();

	void MetodaPuterii();
	void MetodaIteratieiInverse();
	void SVD();

private:
	int  ReadFile(char*);

	int n;
	int p;
	double** A;
	double*  B;
};