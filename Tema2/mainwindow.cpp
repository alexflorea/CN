#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    A = 0;
    d = 0;
    b = 0;

    m = 0;
    n = 0;
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::onLoad()
{
    ui->detEdit->clear();
    ui->detEdit->clear();
    ui->LLEdit->clear();
    ui->normaEdit->clear();
    ui->inputEdit->clear();
    ui->solEdit->clear();

    if(A != 0) {
        for(int i = 0; i < n; i++) {
            free(A[i]);
        }
        free(A);
        A = 0;
    }
    if(d != 0) {
        free(d);
        d = 0;
    }
    if(b != 0) {
        free(b);
        b = 0;
    }

    QFile file(ui->fileNameEdit->text());
    if(!file.open(QIODevice::ReadOnly | QIODevice::Text)) {
        return;
    }

    n = file.readLine().split('\n').at(0).toInt(0, 10);
    m = file.readLine().split('\n').at(0).toInt(0, 10);

    A = (double**) malloc (n * sizeof(double*));
    d = (double*)  malloc (n * (sizeof (double)));
    b = (double*)  malloc (n * (sizeof (double)));
    x = (double*) malloc (n * sizeof(double));


    for(int i = 0; i < n; i++) {
        A[i] = (double*)  malloc (n * (sizeof (double)));
        QList<QByteArray> numbers = file.readLine().split(' ');
        for(int j = 0; j < n; j++) {
            A[i][j] = numbers.at(j).split('\n').at(0).toDouble();
        }
        d[i] = A[i][i];
    }

    QList<QByteArray> numbers = file.readLine().split(' ');
    for(int j = 0; j < n; j++) {
        b[j] = numbers.at(j).split('\n').at(0).toDouble();
    }

    printInput();
    calcDesc();
    calcDet();
    calcSol();
    calcNorma();
}

void MainWindow::printInput()
{
    for(int i = 0; i < n; i++) {
        for(int j = 0; j < n; j++) {
            ui->inputEdit->insertPlainText(QString::number(A[i][j]));
            ui->inputEdit->insertPlainText(" ");
        }
        ui->inputEdit->insertPlainText("\n");
    }
}

void MainWindow::calcDesc()
{
    for(int p = 0; p < n; p++) {
        //Diag
        double temp = A[p][p];
        for(int i = 0; i < p; i++) {
            temp -= A[p][i] * A[p][i];
        }
        if(temp >= 0) {
            A[p][p] = sqrt(temp);
        } else {
            ui->LLEdit->append("Eroare la calcul (temp < 0)");
            return;
        }

        //Rest
        for(int i = p + 1; i < n; i++) {
            temp =  A[i][p];
            for(int k = 0; k < p; k++) {
                temp -= A[i][k] * A[p][k];
            }
            if(A[p][p] < 0.0000000001 && A[p][p] > -0.0000000001) {
                ui->LLEdit->append("Eroare la calcul (A[p][p] == 0)");
                return;
            } else {

                A[i][p] = temp / A[p][p];
            }
        }
    }

    printDesc();
}

void MainWindow::printDesc()
{
    for(int i = 0; i < n; i++) {
        for(int j = 0; j < n; j++) {
            ui->LLEdit->insertPlainText(QString::number(A[i][j]));
            ui->LLEdit->insertPlainText(" ");
        }
        ui->LLEdit->insertPlainText("\n");
    }
}

void MainWindow::calcDet()
{
    double det = 1.0;
    for(int i = 0; i < n; i++) {
        det *= A[i][i] * A[i][i];
    }

    ui->detEdit->append(QString::number(det));
}

void MainWindow::calcSol()
{

    for(int i = 0; i < n; i++) {
        double temp = b[i];
        for(int j = 0; j < i; j++) {
            temp -= A[i][j] * x[j];
        }
        x[i] = temp / A[i][i];
    }

    for(int i = n - 1; i >= 0; i--) {
        double temp = x[i];
        for(int j = i + 1; j < n; j++) {
            temp -= A[j][i] * x[j];
        }
        x[i] = temp / A[i][i];
    }

    for(int j = 0; j < n; j++) {
        ui->solEdit->insertPlainText(QString::number(x[j]));
        ui->solEdit->insertPlainText(" ");
    }
}

void MainWindow::calcNorma()
{
    double* norma = (double*) malloc (n * sizeof(double));

    for(int i = 0; i < n; i++) {
        double temp = 0;
        for(int j = 0; j < n; j++) {
            if(j < i) {
                temp += A[j][i] * x[j];
            } else if(j == i) {
                temp += d[i] * x[j];
            } else if(j > i) {
                temp += A[i][j] * x[j];
            }
        }
        norma[i] = temp - b[i];
    }

    double N = 0;
    for(int i = 0; i < n; i++) {
        N += norma[i] * norma[i];
    }
    N = sqrt(N);
    ui->normaEdit->insertPlainText(QString::number(N, 'g', 40));
}
