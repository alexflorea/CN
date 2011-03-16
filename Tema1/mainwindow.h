#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <math.h>
#include <stdio.h>


namespace Ui {
    class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

public slots:
    void startP1();
    void startP2();
    void startP3();

private:
    Ui::MainWindow *ui;
    double u;
    double PI;
    double Double_PI;

private:
    void calcU(bool);
    void calcSin(double);
    void calcCos(double);
    double formatare(double);
};

#endif // MAINWINDOW_H
