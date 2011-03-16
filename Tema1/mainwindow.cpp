#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    this->u = -1;
    this->PI = 4 * atan(1.0);
    this->Double_PI = this->PI * 2;
    this->ui->comboBox->addItem("sin");
    this->ui->comboBox->addItem("cos");
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::startP1()
{
    ui->textEdit->clear();
    calcU(true);
}

void MainWindow::startP2()
{
    if(u == -1) {
        calcU(false);
    }
    if((u+u)+1.0 == (1.0+u)+u) {
        ui->textEdit_2->append(QString("%1 == %2").arg(QString::number((u+u)+1.0, 'f', 40)).arg(QString::number((1.0+u)+u, 'f', 40)));
    } else {
        ui->textEdit_2->append(QString("%1 != %2").arg(QString::number((u+u)+1.0, 'f', 40)).arg(QString::number((1.0+u)+u, 'f', 40)));
    }
}

void MainWindow::startP3()
{
    if(u == -1) {
        calcU(false);
    }
    ui->textEdit_3->clear();

    bool ok;
    double x = ui->lineEdit->text().toDouble(&ok);
    if(!ok) {
        ui->textEdit_3->append("Eroare in input");
        return;
    }
    double newX = formatare(x);
    if(!ui->comboBox->currentText().compare("sin")) {
        calcSin(newX);
        ui->textEdit_3->append("Target:");
        ui->textEdit_3->append(QString("sin(%1)= %2").arg(x).arg(sin(x)));
    } else {
        calcCos(newX);
        ui->textEdit_3->append("Target:");
        ui->textEdit_3->append(QString("cos(%1)= %2").arg(x).arg(cos(x)));
    }
}

void MainWindow::calcSin(double x)
{
    double s = x;
    double sum = s;
    int i = 0;
    while (fabs(s) > u) {
        double numarator = x * x * s;
        double numitor = (2*i + 2) * (2*i + 3);
        s = -(numarator / numitor);
        sum += s;
        i++;
    }
    ui->textEdit_3->append(QString("sin(%1)= %2").arg(x).arg(sum));
}

void MainWindow::calcCos(double x)
{
    double t = 1;
    double sum = t;
    int i = 0;
    while (fabs(t) > u) {
        double numarator = x * x * t;
        double numitor = (2*i + 1) * (2*i + 2);
        t = -(numarator / numitor);
        sum += t;
        i++;
    }
    ui->textEdit_3->append(QString("cos(%1)= %2").arg(x).arg(sum));
}

double MainWindow::formatare(double x)
{
    double newX = x;
    if(x < -PI) {
        int diff_times = ((int)((x - (-PI)) / (-Double_PI))) + 1;
        newX = x - (diff_times * (-Double_PI));
    } else if (x > PI) {
        int diff_times = ((int)((x - PI) / Double_PI)) + 1;
        newX = x - (diff_times * (Double_PI));
    }

//    while(newX < -PI) {
//        newX += Double_PI;
//    }
//    while(newX > PI) {
//        newX -= Double_PI;
//    }
    return newX;
}

void MainWindow::calcU(bool updateGUI)
{
    int m = 1;
    double u = 1;

    do {
        u /= 2;
        if(updateGUI) {
            ui->textEdit->append(QString("m = %1").arg(m));
            ui->textEdit->append(QString("u       = %1").arg(QString::number(u, 'f', 40)));
            ui->textEdit->append(QString("1.0 + u = %1").arg(QString::number(1.0 + u, 'f', 40)));
        }
        m++;
    } while (1.0 + u != 1.0);
    this->u = u;
}
