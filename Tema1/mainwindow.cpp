#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::startP1()
{
    ui->textEdit->clear();
    int m = 1;
    double u = 1;
    while(true) {
        u /= 10;
        ui->textEdit->append(QString("Pentru m = %1").arg(m));
        m++;
        ui->textEdit->append(QString("1.0 + u = %1").arg(QString::number(1.0 + u, 'f', 40)));
        ui->textEdit->append(QString("u = %1").arg(QString::number(u, 'f', 30)));
        if(1.0 + u == 1.0)
            break;
    }

    if((u+u)+1.0 == (1.0+u)+u)
        ui->textEdit->append(QString("Egal"));
    else
        ui->textEdit->append(QString("Not egal"));
}
