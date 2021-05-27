package geometria;

public class Cubo implements Comparable<Cubo>
{
    double lado = 0.0;

    public Cubo(double lado)
    {
        this.lado = lado;
    }

    double area()
    {
        return (6*(Math.pow(lado, 2)));
    }

    @Override
    public int compareTo(Cubo c) 
    {
        return (int) (this.area() - c.area());
    }

    @Override
    public String toString() 
    {
        return String.format("cubo de area %.1f", this.area());
    }
}
