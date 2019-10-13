#include <iostream>
#include <vector>
#include <iomanip>
#include <cmath>
#include <locale>
#include <fstream>
#define RK2
using namespace std;

ofstream fout;

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

	#ifdef RK2
		hAvn[0] = v[0] + ((a11 * v[0] + a12 * v[1]) * (h / 2.0));
		hAvn[1] = v[1] + ((a21 * v[0] + a22 * v[1]) * (h / 2.0));


		res[0] = v[0] + h * (a11 * hAvn[0] + a12 * hAvn[1]);
		res[1] = v[1] + h * (a21 * hAvn[0] + a22 * hAvn[1]);
	#else 
		hAvn[0] = h * (a11 * v[0] + a12 * v[1]);
		hAvn[1] = h * (a21 * v[0] + a22 * v[1]);

		res[0] = v[0] + hAvn[0];
		res[1] = v[1] + hAvn[1];
	#endif 
	return res;
}

double GetLocalError(vector<double> a, vector<double> b) 
{
	double s1 = (a[0] - b[0]) / 3.0;
	double s2 = (a[1] - b[1]) / 3.0;
	if (s1 > s2) return s1;
	else return s2;
}

void InsertRow(double x, double h, double v1, double v2, double u1, double u2)
{
	fout << x << ";" << h << ";" << v1 << ";" << v2 << ";";
	fout << u1 << ";" << u2 << ";" << v1 - u1 << ";" << v2 - u2 << endl;	
}

bool ControlError(double* x, double* h, vector<double>* v, vector<double>* vprev, const double& s, const double& eps) 
{
	if (fabs(s) > eps) {
		*x -= *h;
		*v = *vprev;
		*h /= 2.0;
		return false;
	} else if (fabs(s) < (eps) / 8) {
		*vprev = *v;
		*h *= 2.0;
	} else {
		*vprev = *v;
	}
	return true;
}

int main() 
{
	setlocale(LC_ALL, "Russian");
	int N;
	double h, eps, x = x10, s;
	fout.open("results.csv");

	cin >> N; cin >> h; cin >> eps;

	fout << setprecision(30);
	fout << " N = " << N << "; h = " << h << endl;
	fout << "x;" << "h;"<< "v1;" <<"v2;" << "u1;" << "u2;" << "v1 - u1;" << "v2 - u2;"<< endl;

	vector<double> vNum(2);
	vector<double> vNumPrev(2);
	vector<double> vNum2(2);
	vector<double> vExact(2);
	vNum[0] = vNum2[0] = vNumPrev[0] = vExact[0] = u10;
	vNum[1] = vNum2[1] = vNumPrev[0] = vExact[1] = u20;

	InsertRow(x, h, vNum[0], vNum[1], vExact[0], vExact[1]);

	for(int i = 0; i < N; i++) {
		x += h;
		vNum2 = GetNumericalSolve(x, vNum, h / 2.0);
		vNum2 = GetNumericalSolve(x + h / 2.0, vNum2, h / 2.0);
		vNumPrev = vNum;
		vNum = GetNumericalSolve(x, vNum, h);
		s = GetLocalError(vNum, vNum2);
		if (!ControlError(&x, &h, &vNum, &vNumPrev, s, eps)) continue;
		vExact = GetExactSolve(x);
		InsertRow(x, h, vNum[0], vNum[1], vExact[0], vExact[1]);
	}
}

