#include <iostream>
#include <vector>
#include <iomanip>
#include <cmath>
#include <locale>
#include <fstream>

using namespace std;

const double a11 = -500.005;
const double a12 = 499.995;
const double a21 = 499.995;
const double a22 = -500.005;

const double x10 = 0.0;
const double x20 = 0.0;
const double u10 = 7.0;
const double u20 = 13.0;

vector<double> GetExactSolve(double x)
{
	vector<double> u(2);
	u[0] = 10.0 * exp(-0.01 * x) - 3 * exp(-1000 * x);
	u[1] = 10.0 * exp(-0.01 * x) + 3 * exp(-1000 * x);
	return u;
}

vector<double> GetNumericalSolve(double x, vector<double> v, double h)
{
	vector<double> res(2);
	vector<double> hAvn(2);

	hAvn[0] = v[0] + ((a11 * v[0] + a12 * v[1]) * (h / 2.0));
	hAvn[1] = v[1] + ((a21 * v[0] + a22 * v[1]) * (h / 2.0));

	res[0] = v[0] + h * (a11 * hAvn[0] + a12 * hAvn[1]);
	res[1] = v[1] + h * (a21 * hAvn[0] + a22 * hAvn[1]);

	return res;
}

int main() 
{
	setlocale(LC_ALL, "Russian");
	int N;
	double h, x = x10;
	ofstream fout;
	fout.open("results.csv");


	cin >> N; cin >> h;
	fout << setprecision(30);
	fout << " N = " << N << "; h = " << h << endl;
	fout << "x;" << "v1;" <<"v2;" << "u1;" << "u2;" << endl;

	vector<double> vNum(2);
	vector<double> vExact(2);
	vNum[0] = vExact[0] = u10;
	vNum[1] = vExact[1] = u20;

	for(int i = 0; i < N; i++) {
		fout << x << ";" << vNum[0] << ";" << vNum[1] << ";";
		fout << vExact[0] << ";" << vExact[1] << endl;
		x += h;
		vNum = GetNumericalSolve(x, vNum, h);
		vExact = GetExactSolve(x);
	}
}