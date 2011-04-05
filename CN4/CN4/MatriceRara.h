#include <fstream>
using namespace std;

class MatriceRara

{
public:
	bool ReadFile(char* t);
	void PrintAllAtributes();

	//Linia i si coloana j
	double A(int i, int j);
	double B(int i, int j);
	void loadSample();
	double iteratie();
	void print();
	void printX();
	bool rezolva();
	double sumaProdus(int i, int jMin, int jMax);
	MatriceRara();
	double verificaSolutie();

private:
	double *d,*val,*b,*x;
	int *linii,*col;
	
	int n;
	int NN;
};