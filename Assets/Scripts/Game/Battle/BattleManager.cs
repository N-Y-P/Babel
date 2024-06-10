using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static EnemyState;

public class BattleManager : MonoBehaviour
{
    [Header("필요한 오브젝트 할당")]
    public GameObject enemy_State_Obj;//적 상태 오브젝트(적 사망 시 비활 목적)
    public GameObject battleWindow; // 전투 창 오브젝트
    public GameObject TransparentWall;//투명 창

    [Header("스크립트 참조")]
    public Player player; // 플레이어 참조
    public EnemyState currentEnemy; // 현재 전투 중인 적
    public EnemyStateUI currentEnemyUI;
    public EnemyHealth currentEnemyHealth;
    //public BattleUIManager battleUImanager;
    public static BattleManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // 이 메소드는 외부에서 현재 전투 중인 적의 EnemyState와 EnemyHealth를 설정하기 위해 사용
    public void SetCurrentEnemy(EnemyState enemyState, EnemyHealth enemyHealth)
    {
        currentEnemy = enemyState;
        currentEnemyHealth = enemyHealth;
        // 적 정보 설정 시, 필요하다면 UI 업데이트 로직도 추가 가능
        if (currentEnemyUI != null && currentEnemyHealth != null)
        {
            currentEnemyUI.UpdateEnemyState(currentEnemy, currentEnemyHealth.currentHealth);
        }
    }
    #region /***버튼 메소드***/
    // 각 버튼 클릭시 호출될 메소드
    public void AttackOption1()
    {
        StartCoroutine(CombatSequence(0));
        //PerformAttack(0); 
    }

    public void AttackOption2()
    {
        StartCoroutine(CombatSequence(1));

        
    }

    public void AttackOption3()
    {
        StartCoroutine(CombatSequence(3));
        //PerformAttack(2); 
    }
    #endregion
    #region/***공격실행, 데미지, 죄책감 메소드***/
    // 공격 실행 메소드
    private void PerformAttack(int optionIndex)
    {
        if (currentEnemyHealth == null || optionIndex >= currentEnemyHealth.enemyState.attackOptions.Length)
        {
            Debug.LogError("잘못된 공격 옵션이거나 적이 설정되지 않았습니다.");
            return;
        }

        var attackOption = currentEnemyHealth.enemyState.attackOptions[optionIndex];

        // 랜덤 확률을 계산하여 공격의 명중 여부 결정
        if (Random.Range(0, 100) < attackOption.accuracy)
        {
            // 공격 명중 시
            // 적의 체력 감소 
            float damage = CalculateDamage(attackOption.damageMultiplier);
            currentEnemyHealth.TakeDamage(damage);

            if (currentEnemyHealth.currentHealth <= 0)
            {
                enemy_State_Obj.SetActive(false);  // 적 UI 비활성화
            }

            // 적 체력 UI 업데이트
            if (currentEnemyUI != null)
            {
                currentEnemyUI.UpdateEnemyState(currentEnemyHealth.enemyState, currentEnemyHealth.currentHealth);  // 체력 표시 업데이트
            }

            // 죄책감 적용
            ApplyGuilt(attackOption.guiltValue);
            BattleUIManager.Instance.DisplayEnemyDamage(damage);
            Debug.Log($"적 공격 옵션 {optionIndex + 1}을 사용. 명중");
        }
        else
        {
            BattleUIManager.Instance.enemyText.text = "놓침";
            // 공격 미스 시
            Debug.Log($"적 공격 옵션 {optionIndex + 1}을 사용. 미스");
        }
    }

    // 데미지 계산 메소드
    private float CalculateDamage(float damageMultiplier)
    {
        // 여기에서 플레이어의 공격력을 기준으로 데미지를 계산
        float minDamage = player.MinAttackCapability * damageMultiplier;  // 소수점 계산을 포함하여 미니멈 데미지 계산
        float maxDamage = player.MaxAttackCapability * damageMultiplier;  // 소수점 계산을 포함하여 맥시멈 데미지 계산
        float finalDamage = Random.Range(minDamage, maxDamage);  // 미니멈과 맥시멈 사이의 랜덤 값을 구함 (소수점 포함)

        // 소수점 첫째 자리에서 반올림하여 처리
        finalDamage = Mathf.Round(finalDamage * 10f) / 10f;

        Debug.Log($"내가 준 피해 {finalDamage}");
        return finalDamage;  // 소수점 첫째 자리까지
    }

    // 죄책감 적용 메소드
    private void ApplyGuilt(int guiltValue)
    {
        // 여기에서 플레이어의 정신 상태에 죄책감을 적용
        player.CurrentMental += guiltValue;
    }
    #endregion

    // 공격과 반격을 처리하는 코루틴
    IEnumerator CombatSequence(int optionIndex)
    {
        // 배틀 스크린을 비활성화
        battleWindow.SetActive(false);
        //투명 벽 활성화(아래 로직이 진행 중일 때 다른 클릭 방지)
        TransparentWall.SetActive(true);

        yield return new WaitForSeconds(0.5f);  // 짧은 지연

        // 플레이어 공격
        PerformAttack(optionIndex);
        yield return new WaitForSeconds(1.0f);  // 플레이어 공격 후 대기

        // 적 반격 
        if (currentEnemyHealth.currentHealth > 0)
        {
            EnemyCounterAttack();
            yield return new WaitForSeconds(1.0f);  // 적 공격 후 대기
        }
        else
        {
            //적이 죽었다면 경험치 부여 
            player.CurrentExp += currentEnemyHealth.enemyState.enemy_Exp;
            BattleUIManager.Instance.DisplayExperienceGained(currentEnemyHealth.enemyState.enemy_Exp);
        }
        // 투명 벽 비활성화
        TransparentWall.SetActive(false);

    }
    private void EnemyCounterAttack()
    {
        // 적이 플레이어에게 공격
        float damage = currentEnemy.GetRandomDamage();
        player.CurrentHP -= damage;
        BattleUIManager.Instance.DisplayPlayerDamage(damage);
        Debug.Log($"적이 {damage} 만큼 공격");
    }
    //상위 전투 메소드(각 버튼 메소드에 넣기)
    //배틀 스크린 닫기(완)
    //투명 벽 true(완)
    //플레이어 공격 모션->데미지text->적의 공격 모션->데미지 text
    //투명 벽 false

    //만약 적 체력 0 이하(사망)
    //false(완)
    //적 land 모션
    //경험치 증가 text


}
