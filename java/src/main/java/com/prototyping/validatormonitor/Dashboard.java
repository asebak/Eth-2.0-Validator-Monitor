package com.prototyping.validatormonitor;

import com.prototyping.validatormonitor.integration.beaconchain.ApiClient;
import com.prototyping.validatormonitor.integration.beaconchain.ApiException;
import com.prototyping.validatormonitor.integration.beaconchain.api.ValidatorApi;
import com.prototyping.validatormonitor.integration.infura.BeaconApi;

import javax.swing.*;

public class Dashboard {
    private JPanel mainPanel;

    public static void main(String[] args) {
        JFrame frame = new JFrame("ETH 2.0 Validator Monitor");
        frame.setContentPane(new Dashboard().mainPanel);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.pack();
        frame.setVisible(true);

        //ApiClient apiClient = new ApiClient();
        //apiClient.setBasePath("https://beaconcha.in");
        //ValidatorApi apiInstance = new ValidatorApi(apiClient);
        //  String result = apiInstance.apiV1ValidatorIndexOrPubkeyGet("1000");
        ApiClient apiClient = new ApiClient();
        apiClient.setBasePath(Constants.INFURA_ENDPOINT);
        BeaconApi apiInstance = new BeaconApi(apiClient);
        try {
           Object result = apiInstance.validatorStatusApi("1000");
            System.out.println(result);
        } catch (ApiException e) {
            System.err.println("Exception when calling BlockApi#apiV1BlockSlotAttestationsGet");
            e.printStackTrace();
        }
    }
}
