#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QFile>

#include "math.h"

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
    void onLoad();

private:
    Ui::MainWindow *ui;

    double** A;
    double*  d;
    double*  b;
    double*  x;

    int n, m;

private:
    void printInput();
    void calcDesc();
    void printDesc();

    void calcDet();
    void calcSol();

    void calcNorma();
};

#endif // MAINWINDOW_H
