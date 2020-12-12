/*
 * Beaconcha.in ETH2 API
 * High performance API for querying information from the Ethereum 2.0 beacon chain The API is currently free to use. A fair use policy applies. Calls are rate limited to 10 requests / 1 minute / IP. All API results are cached for 1 minute. If you required a higher usage plan please checkout https://beaconcha.in/pricing.
 *
 * OpenAPI spec version: 1.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */


package com.prototyping.validatormonitor.integration.beaconchain.model;

import java.util.Objects;

import com.google.gson.annotations.SerializedName;
import io.swagger.annotations.ApiModelProperty;

/**
 * UtilsOAuthErrorResponse
 */
@javax.annotation.Generated(value = "io.swagger.codegen.languages.JavaClientCodegen", date = "2020-12-12T13:45:51.285Z")



public class UtilsOAuthErrorResponse {
  @SerializedName("error")
  private String error = null;

  @SerializedName("error_description")
  private String errorDescription = null;

  public UtilsOAuthErrorResponse error(String error) {
    this.error = error;
    return this;
  }

   /**
   * Get error
   * @return error
  **/
  @ApiModelProperty(value = "")
  public String getError() {
    return error;
  }

  public void setError(String error) {
    this.error = error;
  }

  public UtilsOAuthErrorResponse errorDescription(String errorDescription) {
    this.errorDescription = errorDescription;
    return this;
  }

   /**
   * Get errorDescription
   * @return errorDescription
  **/
  @ApiModelProperty(value = "")
  public String getErrorDescription() {
    return errorDescription;
  }

  public void setErrorDescription(String errorDescription) {
    this.errorDescription = errorDescription;
  }


  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    UtilsOAuthErrorResponse utilsOAuthErrorResponse = (UtilsOAuthErrorResponse) o;
    return Objects.equals(this.error, utilsOAuthErrorResponse.error) &&
        Objects.equals(this.errorDescription, utilsOAuthErrorResponse.errorDescription);
  }

  @Override
  public int hashCode() {
    return Objects.hash(error, errorDescription);
  }


  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class UtilsOAuthErrorResponse {\n");
    
    sb.append("    error: ").append(toIndentedString(error)).append("\n");
    sb.append("    errorDescription: ").append(toIndentedString(errorDescription)).append("\n");
    sb.append("}");
    return sb.toString();
  }

  /**
   * Convert the given object to string with each line indented by 4 spaces
   * (except the first line).
   */
  private String toIndentedString(Object o) {
    if (o == null) {
      return "null";
    }
    return o.toString().replace("\n", "\n    ");
  }

}
