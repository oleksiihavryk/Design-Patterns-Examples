namespace CreatingPatterns.Builder;

public interface IBurgerBuilder
{
    IBurgerBuilder AddTartarSauce(int howMuch);
    IBurgerBuilder AddHotSauce(int howMuch);
    IBurgerBuilder AddTacoSauce(int howMuch);
    IBurgerBuilder AddBarbecueSauce(int howMuch);
    IBurgerBuilder AddCheese(int howMuch);
    IBurgerBuilder AddTomatoes(int howMuch);
    IBurgerBuilder AddBeef(int howMuch);
    IBurgerBuilder AddPork(int howMuch);
    IBurgerBuilder AddCucumbers(int howMuch);
    IBurgerBuilder AddOnions(int howMuch);
    Burger Build();
}