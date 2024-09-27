// worrior , wizard , assassin 직업 만들기 O
// Level , Name , AttackPower , Defense , HealthPoint O
// Critical , Dodge , Gold , IsDead 
// 직업에 중첩된 부분을 묶기
// 피격당하고 공격할 수 있는 코드짜기
// 능력치 할당 O
// 캐릭터별 Skill 기능 O
// 방어나 공격같은 행동을 취했을 때 특수 스탯적용
// 캐릭터 생성

class Worrior
{
    int Level;
    string Name;
    int AttackPower = 20;
    int Defense = 10;
    int HealthPoint = 150;
    int MP = 40;
    bool IsDead => HealthPoint <= 0;
    
    void TakeDamage(int damage)
    {
        HealthPoint -= damage;
        if (IsDead) Console.WriteLine($"{Name}(이)가 죽었습니다.");
        else Console.WriteLine($"{Name}(이)가 {damage}의 데미지를 받았습니다. 남은체력 : {HealthPoint}");
    }

    void Skill()
    {
        double Q = (AttackPower) + (Defense);
        double R = (Defense) * 2; //공격력으로 치환
    }
}
class Wizard
{
    int Level;
    string Name;
    int AttackPower = 25;
    int Defense = 7;
    int HealthPoint = 120;
    int MP = 60;
    bool IsDead => HealthPoint <= 0;
    int Critical = 10; //%로 표시

    void TakeDamage(int damage)
    {
        HealthPoint -= damage;
        if (IsDead) Console.WriteLine($"{Name}(이)가 죽었습니다.");
        else Console.WriteLine($"{Name}(이)가 {damage}의 데미지를 받았습니다. 남은체력 : {HealthPoint}");
    }

    void Skill()
    {
        double Q = (AttackPower) + (Critical);
        double R = (AttackPower) * (5 / Critical);
    }
}
class assassin
{
    int Level;
    string Name;
    int AttackPower = 30;
    int Defense = 5;
    int HealthPoint = 100;
    int MP = 50;
    bool IsDead => HealthPoint <= 0;
    int Dodge = 20; //%로 표시

    void TakeDamage(int damage)
    {
        HealthPoint -= damage;
        if (IsDead) Console.WriteLine($"{Name}(이)가 죽었습니다.");
        if (HealthPoint == HealthPoint) Console.WriteLine($"{Name}(이)가 회피에 성공했습니다!");
        else Console.WriteLine($"{Name}(이)가 {damage}의 데미지를 받았습니다. 남은체력 : {HealthPoint}");
    }

    void Skill()
    {
        double Q = (AttackPower) + (Dodge);
        double R = (Dodge) * 2; //1턴 유지
    }
}