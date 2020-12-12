package com.prototyping.validatormonitor.integration.infura.models;

public class ValidatorStatus {
    public String index;
    public String balance;
    public String status;
    public Validator validator;
    public class Validator{
        public String pubkey;
        public String withdrawal_credentials;
        public String effective_balance;
        public boolean slashed;
        public String activation_eligibility_epoch;
        public String activation_epoch;
        public String exit_epoch;
        public String withdrawable_epoch;
    }

}




