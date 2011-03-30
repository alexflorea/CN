#include <fstream>
#include "MatriceRara.h"

using namespace std;

void MatriceRara::ReadFile(char * t)
	{	
		char c[256]="";
		char *pch;
		d=(double*)calloc(n,sizeof(double));

		ifstream in(t);
		in.getline(c,256);
		n=atoi(c);
		in.getline(c,256);
		for(int i;i<n;i++)
		{
		in.getline(c,256);
		pch = strtok (c," ,");   
		n=atoi(pch);
		pch = strtok (NULL, " ,");
	}
}